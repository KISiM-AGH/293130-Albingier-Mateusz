using FullStack_Project_IE_2.Domain.Models;

namespace FullStack_Project_IE_2.Domain.Services.Communication
{
    public class CompetitionResponse : BaseResponse
    {
        public Competition competition { get; private set; }

        public CompetitionResponse(bool success, string message, Competition competition) : base(success, message)
        {
            this.competition = competition;
        }

        public CompetitionResponse(Competition competition) : this(true, string.Empty, competition) { }
        public CompetitionResponse(string message) : this(false, message, null) { }
    }
}
