using TMPro;
using UnityEngine;
using VContainer;
using VoxInvasion.Runtime.Services.FatalError;

namespace VoxInvasion.Runtime.UI.FatalError
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