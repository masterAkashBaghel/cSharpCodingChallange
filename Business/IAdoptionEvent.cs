using System.Collections.Generic;

namespace Business
{
    public interface IAdoptionEvent
    {
        void HostEvent();

        void RegisterParticipant(IAdoptable participant);
    }
}