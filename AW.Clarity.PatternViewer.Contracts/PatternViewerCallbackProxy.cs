using AW.Clarity.PatternViewer.Contracts.Interfaces;
using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Exceptions;
using AWSOA.Core.Contracts.Trace;

namespace AW.Clarity.PatternViewer.Contracts
{
    //ICE PROXY  - Ruft den (impliziten) ICE Service auf der Client Seite   (OEvent)

    public class PatternViewerCallbackProxy : IPatternViewerCallback
    {
        /// <summary>
        /// The public getter of the Ice Identity
        /// </summary>
        public Ice.Identity IceIdentity { get { return this.CallbackProxy.ice_getIdentity(); } }

        /// <summary>
        /// The public getter of the Ice Identity
        /// </summary>
        public Ice.Communicator IceCommunicator { get { return this.CallbackProxy.ice_getCommunicator(); } }

        /// <summary>
        /// The Ice callback proxy for a Pattern Viewer service
        /// </summary>
        public PatternViewerCallbackPrx CallbackProxy { get; private set; }

        public string MachineLabel { get; set; }

        public Ice.Identity CallingIceIdentity { get; set; }

        public PatternViewerCallbackProxy()
        {            
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceClientProxy">the client proxy for the service</param>
        public PatternViewerCallbackProxy(Ice.ObjectPrx iceCallbackObjProxy)
        {
            try
            {
                // This will result in a oneway call to the servant(fire and forget)
                // Default is a twoway. Every call to the servant is blocking until the servant finished its processing.

                //var iceObj = PatternViewerCallbackPrxHelper.uncheckedCast(serviceClientProxy);

                this.CallbackProxy = (PatternViewerCallbackPrx)PatternViewerCallbackPrxHelper.checkedCast(iceCallbackObjProxy).ice_oneway();

                if (this.CallbackProxy == null)
                {
                    throw ExceptionFactory.CreateCoreNullReferenceException(1000653, "CallbackProxy for PatternViewerCallbackProxy is null");
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void BreakageReasonSelected(GuidDto sheet, int reason, Ice.Optional<string> machineLabel)
        {
            TraceFactory.Trace(178, 0, "Calling PatternViewerCallback.BreakageReasonSelected\n  sheet '{0}'\n  reason '{1}' machineLabel '{2}'", 
                sheet, reason, machineLabel);

            try
            {
                this.CallbackProxy.BreakageReasonSelected(sheet, reason, machineLabel);
            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "BreakageReasonSelected");
            }
            
        }

        public void InputEvent(AW.Clarity.PatternViewer.Contracts.DataTransferObject.InputEventDto inputEvent, Ice.Optional<string> machineLabel)
        {
            TraceFactory.Trace(178, 0, "Calling PatternViewerCallback.InputEvent\n  inputEvent '{0}' machineLabel '{1}'", inputEvent, machineLabel);

            try
            {
                this.CallbackProxy.InputEvent(inputEvent, machineLabel);
            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "InputEvent");
            }
        }

        public void StepPattern(AW.Clarity.PatternViewer.Contracts.DataTransferObject.StepPatternEventDto stepPatternEvent, Ice.Optional<string> machineLabel)
        {
            TraceFactory.Trace(178, 0, "Calling PatternViewerCallback.StepPattern\n  stepPatternEvent '{0}' machineLabel '{1}'", stepPatternEvent, machineLabel);
            try
            {
                this.CallbackProxy.StepPattern(stepPatternEvent, machineLabel);
            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "StepPattern");
            }
        }

        public void CreateBreakageWithReason(AW.Clarity.PatternViewer.Contracts.DataTransferObject.CreateBreakageRequestDto createBreakageRequestDto, string machineLabel)
        {
            TraceFactory.Trace(178, 0, "Calling PatternViewerCallback.CreateBreakageWithReason\n  CreateBreakageRequestDto '{0}' machineLabel '{1}'", createBreakageRequestDto, machineLabel);

            try
            {
                this.CallbackProxy.CreateBreakageWithReason(createBreakageRequestDto, machineLabel);
            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "CreateBreakageWithReason");
            }
        }
    }
}