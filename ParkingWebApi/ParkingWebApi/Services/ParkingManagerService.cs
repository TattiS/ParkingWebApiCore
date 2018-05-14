using ParkingLibrary.Classes;

namespace ParkingWebApi.Services
{
    public class ParkingManagerService
    {
        public ParkManagerHelper Helper { get; private set; }
        public ParkingManagerService()
        {
            Helper = new ParkManagerHelper();
        }

    }
}
