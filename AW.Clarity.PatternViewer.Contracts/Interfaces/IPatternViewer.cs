using AW.Clarity.PatternViewer.Contracts.DataTransferObject;

using AWSOA.Core.Contracts.DataTransferObject;

using System.Collections.Generic;

namespace AW.Clarity.PatternViewer.Contracts.Interfaces
{
    /// <summary>
    /// Interface for the service
    /// </summary>
    public partial interface IPatternViewer 
    {
		VersionDto GetVersion();

		bool CallbackIsValid();

		void ShowPattern(PatternDto pattern, HeaderInformationDto headerInformation, FooterInformationDto footerInformation, List<string> informations, Ice.Optional<bool> singleSheet, Ice.Optional<bool> showInfoText);

		/**
		* Shows the breakage reason dialog in the pattern viewer.
		**/
		void ShowBreakageReasons();

		/**
		* Hiddes the breakage reason dialog in the pattern viewer.
		**/
		void RemoveBreakageReasons();

		/**
		* Shutdowns the pattern viewer instance.
		**/
		void Shutdown();

		/**
		* Subscribe to the pattern viewer to receive callback information.
		* @param machineLabel The machine label for the current pattern viewer instance.
		* @param identity An unique identity to "identify" the callback listener.
		**/
		bool LogOn(string machineLabel, Ice.Identity identity);
		/**
		* Unsubscribe from the pattern viewer to stop receiving callback information.
		* @param machineLabel The machine label for the current pattern viewer instance.
		* @param identity An unique identity to "identify" which callback listener should be unsubscribe
		**/
		bool LogOff(string machineLabel, Ice.Identity identity);
		/**
		* Retrieves the Guid of the current shown pattern
		**/
		GuidDto CurrentPattern();

	}
}