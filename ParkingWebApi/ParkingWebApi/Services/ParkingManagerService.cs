using ParkingLibrary.Classes;

namespace ParkingWebApi.Services
{
    public class ParkingManagerService
    {
        public ParkManagerHelper helper { get; private set; }
        public ParkingManagerService()
        {
            helper = new ParkManagerHelper();
        }

    }
}
