using FullStack_Project_IE_2.Domain.Models;

namespace FullStack_Project_IE_2.Domain.Services.Communication
{
    public class DancerResponse : BaseResponse
    {

        public Dancer User { get; private set;}

        private DancerResponse(bool success, string message, Dancer user) : base(success, message)
        {
            User = user;
        }

        public DancerResponse(Dancer user) : this(true, string.Empty, user) { }
        public DancerResponse(string message) : this(false, message, null) { }

    }
}
