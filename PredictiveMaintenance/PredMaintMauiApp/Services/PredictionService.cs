
namespace PredMaintMauiApp.Services
{
    public class PredictionService
    {
        public float Predict(PredictiveMaintenanceModel.ModelInput modelInput)
        {            
            var output = PredictiveMaintenanceModel.Predict(modelInput);
            return output.PredictedLabel;
        }
    }
}
