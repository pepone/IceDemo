using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ice;

using AWSOA.Core.Contracts.Exceptions;
using AWSOA.Core.Contracts.Trace;
using AW.Clarity.PatternViewer.Contracts;
using AW.Clarity.PatternViewer.Contracts.Interfaces;
using System.Diagnostics;

namespace AW.Clarity.PatternViewer.Contracts.Interfaces
{
    public partial class PatternViewerProxy : IPatternViewer
    {
        /// <summary>
        /// The callback adapter that is used for the current connection
        /// </summary>
        private Ice.ObjectAdapter callbackAdapter;

        /// <summary>
        /// The Slice generated Proxy helper
        /// </summary>
        public PatternViewPrx IceProxy { get; private set; }

        /// <summary>
        /// The action that will be executed inside the ComProxy for doing a reconnection
        /// </summary>
        public Action CallbackAction { get; set; }


        public bool HasCallbackAdapter
        {
            get
            {
                return this.IceProxy.ice_getConnection().getAdapter() != null;
            }
        }

        public Ice.Connection IceConnection
        {
            get
            {
                return this.IceProxy.ice_getConnection();
            }
        }
        #region Constructors

        /// <summary>
        /// Constructor of the Service Proxy
        /// </summary>
        /// <param name="serviceClientProxy">the client proxy for the service</param>
        public PatternViewerProxy(Ice.ObjectPrx serviceClientProxy)
        {
            if (serviceClientProxy == null)
            {
                throw ExceptionFactory.CreateCoreNullReferenceException(1000668, "Proxy is null");
            }

            try
            {
                this.IceProxy = PatternViewPrxHelper.checkedCast(serviceClientProxy);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewer Proxy create");
            }
            if (this.IceProxy == null)
            {
                throw ExceptionFactory.CreateCoreNullReferenceException(1000724, "IceProxy for PatternViewerProxy is null");
            }
        }
        /// <summary>
        /// Constructor of the Service Proxy with an callback Adapter
        /// https://doc.zeroc.com/display/Ice37/Bidirectional+Connections
        /// </summary>
        /// <param name="serviceClientProxy">the ICE client proxy for the service</param>
        /// <param name="callbackAdapter">the ICE client proxy for the service</param>
        public PatternViewerProxy(Ice.ObjectPrx serviceClientProxy, Ice.ObjectAdapter callbackAdapter)
        {
            if (serviceClientProxy == null)
            {
                throw ExceptionFactory.CreateCoreNullReferenceException(1000719, "Proxy is null");
            }

            if (callbackAdapter == null)
            {
                throw ExceptionFactory.CreateCoreNullReferenceException(1000720, "Callback Adapter is null");
            }

            try
            {
                this.IceProxy = PatternViewPrxHelper.checkedCast(serviceClientProxy);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewer Proxy create");
            }
            if (this.IceProxy == null)
            {
                throw ExceptionFactory.CreateCoreNullReferenceException(1000723, "IceProxy for PatternViewerProxy is null");
            }

            this.callbackAdapter = callbackAdapter;

            // set the callback adapter on the client connection
            this.IceProxy.ice_getConnection().setAdapter(callbackAdapter);
        }
        /// <summary>
        /// Constructor of the Service Proxy - Create a copy with the own context.
        /// </summary>
        /// <param name="serviceClientProxy">the client proxy for the service</param>
        /// <param name="context">the per-proxy request context</param>
        public PatternViewerProxy(Ice.ObjectPrx serviceClientProxy, Dictionary<string, string> context)
        {
            if (serviceClientProxy == null)
            {
                throw ExceptionFactory.CreateCoreNullReferenceException(1000721, "Proxy is null");
            }

            try
            {
                this.IceProxy = PatternViewPrxHelper.checkedCast(serviceClientProxy.ice_context(context));
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewer Proxy create");
            }
            if (this.IceProxy == null)
            {
                throw ExceptionFactory.CreateCoreNullReferenceException(1000652, "IceProxy for PatternViewerProxy is null");
            }
        }

        /// <summary>
        /// Constructor  of the Service Proxy - Create a copy with the own context.
        /// </summary>
        /// <param name="proxy">the proxy for the service</param>
        /// <param name="context">the per-proxy request context</param>
        public PatternViewerProxy(PatternViewerProxy proxy, Dictionary<string, string> context)
        {
            if (proxy == null)
            {
                throw ExceptionFactory.CreateCoreNullReferenceException(1000722, "Proxy is null");
            }

            try
            {
                this.IceProxy = PatternViewPrxHelper.checkedCast(proxy.IceProxy.ice_context(context));
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewer Proxy create");
            }
            if (this.IceProxy == null)
            {
                throw ExceptionFactory.CreateCoreNullReferenceException(1000667, "IceProxy for PatternViewerProxy is null");
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the Proxy request context
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public Dictionary<string, string> Context
        {
            get
            {
                return this.IceProxy.ice_getContext();
            }
            set
            {
                try
                {
                    this.IceProxy = PatternViewPrxHelper.checkedCast(this.IceProxy.ice_context(value));
                }
                catch (Ice.Exception iceEx)
                {
                    ExceptionHelper.HandleIceException(iceEx, "PatternViewer Context");
                }
                if (this.IceProxy == null)
                {
                    throw ExceptionFactory.CreateCoreNullReferenceException(1000653, "IceProxy for PatternViewerProxy is null");
                }
            }
        }

        #region ReconnectCallbacks

        private void ReconnectCallbacks()
        {
            ReconnectCallbacks(true);
        }
        /// <summary>
        /// Execute the reconnection, if necessary
        /// </summary>
        public void ReconnectCallbacks(bool invokeCallbackAction)
        {
            // Reconnect only necessary if client uses CallbackAction
            if (this.CallbackAction != null)
            {
                if (this.callbackAdapter != null)
                {
                    if (this.IceProxy == null || this.IceProxy.ice_getConnection() == null)
                    {
                        return;
                    }

                    // Try to call "CallbackIsValid" from Service. This function may not exist and exception "Ice.OperationNotExistException" will be thrown.
                    try
                    {
                        // Call proxy, Ice runtime invalidates the adapter in case of connection loss
                        this.IceProxy.CallbackIsValid();
                    }
                    catch (Ice.OperationNotExistException)
                    {
                        // Seems to be an old service, remove CallbackAction to prevent further calls to that routine.
                        // Reconnect functionality is not available with that old service
                        this.CallbackAction = null;
                    }

                    // See if adapter is invalid
                    if (!this.HasCallbackAdapter)
                    {
                        // Attach the callback adapter
                        this.AddCallbackAdapter(this.callbackAdapter);

                        if (invokeCallbackAction)
                        {
                            // Execute the user defined reconnect action (lambda)
                            this.CallbackAction?.Invoke();
                        }
                    }

                }
            }
        }
        #endregion

        /// <summary>
        /// Adds an callback adapter to the ice connection.
        /// https://doc.zeroc.com/display/Ice37/Bidirectional+Connections
        /// </summary>
        /// <param name="adapter">The adapter to add.</param>
        public void AddCallbackAdapter(Ice.ObjectAdapter adapter)
        {
            // set the callback adapter on the client connection
            this.IceProxy.ice_getConnection().setAdapter(adapter);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public AWSOA.Core.Contracts.DataTransferObject.VersionDto GetVersion()
        {
            TraceFactory.Trace(178, 0, "Calling PatternViewerService.GetVersion");

            System.Object returnValue = new System.Object();

            try
            {
                // Reconnect in case of connection loss
                this.ReconnectCallbacks();

                returnValue = this.IceProxy.GetVersion();
            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewerService.GetVersion");
            }

            return (AWSOA.Core.Contracts.DataTransferObject.VersionDto)returnValue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public bool CallbackIsValid()
        {
            TraceFactory.Trace(178, 0, "Calling PatternViewerService.CallbackIsValid");

            System.Object returnValue = new System.Object();

            try
            {
                // Reconnect in case of connection loss
                ReconnectCallbacks();

                returnValue = this.IceProxy.CallbackIsValid();
            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewerService.CallbackIsValid");
            }

            return (bool)returnValue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public void ShowPattern(AW.Clarity.PatternViewer.Contracts.DataTransferObject.PatternDto pattern, AW.Clarity.PatternViewer.Contracts.DataTransferObject.HeaderInformationDto headerInformation, AW.Clarity.PatternViewer.Contracts.DataTransferObject.FooterInformationDto footerInformation, List<String> informations, Optional<bool> singleSheet, Optional<bool> showInfoText)
        {
            TraceFactory.Trace(178, 0, "Calling PatternViewerService.ShowPattern\n  pattern '{0}'\n  headerInformation '{1}'\n  footerInformation '{2}'\n  informations '{3}'", pattern, headerInformation, footerInformation, informations);

            try
            {
                // Reconnect in case of connection loss
                this.ReconnectCallbacks();

                this.IceProxy.ShowPattern(pattern, headerInformation, footerInformation, informations, singleSheet, showInfoText);
            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewerService.ShowPattern");
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public void ShowBreakageReasons()
        {
            TraceFactory.Trace(178, 0, "Calling PatternViewerService.ShowBreakageReasons");

            try
            {
                // Reconnect in case of connection loss
                this.ReconnectCallbacks();

                this.IceProxy.ShowBreakageReasons();
            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewerService.ShowBreakageReasons");
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public void RemoveBreakageReasons()
        {
            TraceFactory.Trace(178, 0, "Calling PatternViewerService.RemoveBreakageReasons");

            try
            {
                // Reconnect in case of connection loss
                this.ReconnectCallbacks();

                this.IceProxy.RemoveBreakageReasons();
            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewerService.RemoveBreakageReasons");
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public void Shutdown()
        {
            TraceFactory.Trace(178, 0, "Calling PatternViewerService.Shutdown");

            try
            {
                // Reconnect in case of connection loss
                this.ReconnectCallbacks();

                this.IceProxy.Shutdown();
            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewerService.Shutdown");
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public System.Boolean LogOn(System.String machineLabel, Ice.Identity identity)
        {
            TraceFactory.Trace(178, 0, "Calling PatternViewerService.LogOn\n  machineLabel '{0}'\n  identity '{1}'", machineLabel, identity);

            System.Object returnValue = new System.Object();

            try
            {
                returnValue = this.IceProxy.LogOn(machineLabel, identity);

            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewerService.LogOn");
            }

            return (System.Boolean)returnValue;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public System.Boolean LogOff(System.String machineLabel, Ice.Identity identity)
        {
            TraceFactory.Trace(178, 0, "Calling PatternViewerService.LogOff\n  machineLabel '{0}'\n  identity '{1}'", machineLabel, identity);

            System.Object returnValue = new System.Object();

            try
            {
                // Reconnect in case of connection loss
                this.ReconnectCallbacks();

                returnValue = this.IceProxy.LogOff(machineLabel, identity);
            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewerService.LogOff");
            }

            return (System.Boolean)returnValue;
        }

        public AWSOA.Core.Contracts.DataTransferObject.GuidDto CurrentPattern()
        {
            TraceFactory.Trace(178, 0, "Calling PatternViewerService.CurrentPattern'");

            System.Object returnValue = new System.Object();

            try
            {
                // Reconnect in case of connection loss
                this.ReconnectCallbacks();

                returnValue = this.IceProxy.CurrentPattern();
            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewerService.CurrentPattern");
            }

            return (AWSOA.Core.Contracts.DataTransferObject.GuidDto)returnValue;
        }
    }
}

