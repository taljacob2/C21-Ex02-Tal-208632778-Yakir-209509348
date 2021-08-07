#region

using C21_Ex02_01.Team.UI;

#endregion

namespace C21_Ex02_01.Team.Engine.Service.Impl
{
    public class RequesterServiceImpl : IRequesterService
    {
        private readonly ConsoleUI.Requester r_Responder;

        public RequesterServiceImpl(Engine i_Engine)
        {
            // UI: Choose from which platform to construct the Engine:
            r_Responder = new ConsoleUI.Requester(i_Engine);
        }

        public void RequestAndConstructEngine()
        {
            r_Responder.RequestAndConstructEngine();
        }
    }
}
