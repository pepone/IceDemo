using AW.Clarity.PatternViewer.Contracts.DataTransferObject;

using AWSOA.Core.Contracts.DataTransferObject;

namespace AW.Clarity.PatternViewer.Contracts.Interfaces
{
    //Ice-DELEGATE & Client Event

    public interface IPatternViewerCallback 
    {
        Ice.Identity IceIdentity { get; }

        Ice.Communicator IceCommunicator { get; }

        string MachineLabel { get; set; }

        Ice.Identity CallingIceIdentity { get; set; }

		/**
					* Callback routine from PatternViewer to report an input event.
					* @param inputEvent The input event which was triggered (like left mouse button).
					**/
		void InputEvent(InputEventDto inputEvent, Ice.Optional<string> machineLabel);

		/**
		* Callback routine from PatternViewer which breakage reason is selected.
		* @param sheet The guid of the sheet for which the breakage was selected.
		* @param reason The breakage reason number which was selected.
		**/
		void BreakageReasonSelected(GuidDto sheet, int reason, Ice.Optional<string> machineLabel);

		/**
		* Callback routine from PatternViewer if next or previos button is pressed.
		* @param stepPatternEvent The stepPatternEvent event which was triggert.
		**/
		void StepPattern(StepPatternEventDto stepPatternEvent, Ice.Optional<string> machineLabel);

        /**
		* Callback routine from PatternViewer if next or previos button is pressed.
		* @param stepPatternEvent The stepPatternEvent event which was triggert.
		**/
        void CreateBreakageWithReason(CreateBreakageRequestDto createBreakageRequestDto, string machineLabel);

    }
}
