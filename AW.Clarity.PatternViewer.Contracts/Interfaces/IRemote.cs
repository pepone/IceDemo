using AW.Clarity.PatternViewer.Contracts.DataTransferObject;

using AWSOA.Core.Contracts.DataTransferObject;

namespace AW.Clarity.PatternViewer.Contracts.Interfaces
{
    /// <summary>
    /// Interface for the service
    /// </summary>    
    public partial interface IRemote
    {
		/**
		* Get the Service Version
		* @returns The service version
		**/
		VersionDto GetVersion();

		/**
		* Sent an input action
		**/
		void SendInputAction(InputEventDto inputEvent);

        /**
		* Sent an input action
		**/
        void CreateBreakageWithReason(CreateBreakageRequestDto createBreakageRequestDto);

    }
}