using C21_Ex02_01.Team.UI;

namespace C21_Ex02_01.Team.Engine.Service.Impl
{
    public class ResponderServiceImpl : IResponderService
    {
        private readonly ConsoleUI.Responder r_Responder;

        public ResponderServiceImpl(Engine i_Engine)
        {
            // UI: Choose whom to respond the Engine:
            r_Responder = new ConsoleUI.Responder(i_Engine);
        }

        public void PrintEngineToConsoleUI()
        {
            r_Responder.PrintBoardWithScreenClearBeforePrint();
        }
    }
}
