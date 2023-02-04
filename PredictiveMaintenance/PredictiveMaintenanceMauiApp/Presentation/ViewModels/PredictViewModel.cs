using Microsoft.ML.Data;
using PredictiveMaintenanceMauiApp.Services;
using System.Windows.Input;

namespace PredictiveMaintenanceMauiApp.Presentation.ViewModels
{
    public class PredictViewModel : BaseViewModel
    {

        public PredictionService PredictionService { get; }




        //private float passengerCount;

        //public float PassengerCount
        //{
        //    get { return passengerCount; }
        //    set { SetProperty(ref passengerCount, value); }
        //}

        //private float tripTime;

        //public float TripTime
        //{
        //    get { return tripTime; }
        //    set { SetProperty(ref tripTime, value); }
        //}


        //private float tripDistance;

        //public float TripDistance
        //{
        //    get { return tripDistance; }
        //    set { SetProperty(ref tripDistance, value); }
        //}

        //private float fareAmount;

        //public float FareAmount
        //{
        //    get { return fareAmount; }
        //    set { SetProperty(ref fareAmount, value); }
        //}


        private PredictiveMaintenanceModel.ModelInput modelInput;
        private float uDI;
        private string product_ID;
        private string type;
        private float air_temperature;
        private float process_temperature;
        private float rotational_speed;
        private float torque;
        private float tool_wear;

        public float UDI { get => uDI; set => SetProperty(ref uDI, value); }

        public string Product_ID { get => product_ID; set => SetProperty(ref product_ID, value); }

        public string Type { get => type; set => SetProperty(ref type, value); }

        public float Air_Temperature { get => air_temperature; set => SetProperty(ref air_temperature, value); }

        public float Process_Temperature { get => process_temperature; set => SetProperty(ref process_temperature, value); }

        public float Rotational_Speed { get => rotational_speed; set => SetProperty(ref rotational_speed, value); }

        public float Torque { get => torque; set => SetProperty(ref torque, value); }

        public float Tool_Wear { get => tool_wear; set => SetProperty(ref tool_wear, value); }

        public PredictiveMaintenanceModel.ModelInput ModelInput
        {
            get { return modelInput; }
            set { SetProperty(ref modelInput, value); }
        }

        public ICommand PredictCommand { private set; get; }

        private async Task Predict()
        {
            modelInput = new PredictiveMaintenanceModel.ModelInput()
            {
                UDI = UDI,
                Product_ID = Product_ID,
                Type = Type,
                Air_temperature = Air_Temperature,
                Process_temperature = Process_Temperature,
                Rotational_speed = Rotational_Speed,
                Torque = Torque,
                Tool_wear = Tool_Wear,
            };

            var predictedLabel = PredictionService.Predict(modelInput);
            await Application.Current.MainPage.DisplayAlert("Prediction", $"Machine Failure: {predictedLabel}", "OK");
        }

        public PredictViewModel()
        {
            UDI = 0; //2F;
            Product_ID = @"L47181";
            Type = @"L";
            Air_Temperature = 298.2F;
            Process_Temperature = 308.7F;
            Rotational_Speed = 1408F;
            Torque = 46.3F;
            Tool_Wear = 3F;
            
            PredictionService = new PredictionService();
            PredictCommand = new Command(async () => await Predict());
        }
    }
}