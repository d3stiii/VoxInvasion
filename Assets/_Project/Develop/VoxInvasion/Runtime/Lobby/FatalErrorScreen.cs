using TMPro;
using UnityEngine;
using VContainer;
using VoxInvasion.Runtime.Utilities;
using VoxInvasion.Runtime.Utilities.UI;

namespace VoxInvasion.Runtime.Lobby
{
    public class FatalErrorScreen : BaseScreen
    {
        [SerializeField] private TMP_Text _errorText;
        private ErrorHandler _errorHandler;

        [Inject]
        public void Construct(ErrorHandler handler) =>
            _errorHandler = handler;

        protected override void Initialize()
        {
            _errorText.text = _errorHandler.Error;
        }
    }
}