using FullStack_Project_IE_2.Domain.Models;

namespace FullStack_Project_IE_2.Domain.Services.Communication
{
    public class CoupleResponse : BaseResponse
    {

        public Couple couple { get; private set;}

        public CoupleResponse(bool success, string message, Couple couple) : base(success, message)
        {
            this.couple = couple;
        }

        public CoupleResponse(Couple couple) : this(true, string.Empty, couple){ }
        public CoupleResponse(string message) : this(false, message, null) { }
    }
}
