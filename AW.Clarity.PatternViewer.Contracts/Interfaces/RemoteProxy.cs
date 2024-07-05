using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ice;

using AWSOA.Core.Contracts.Exceptions;
using AWSOA.Core.Contracts.Trace;


namespace AW.Clarity.PatternViewer.Contracts.Interfaces
{
    public partial class RemoteProxy : IRemote
    {
        /// <summary>
        /// The Slice generated Proxy helper
        /// </summary>
        public RemotePrx IceProxy { get; private set; }

        #region Constructors

        /// <summary>
        /// Constructor of the Service Proxy
        /// </summary>
        /// <param name="serviceClientProxy">the client proxy for the service</param>
        public RemoteProxy(Ice.ObjectPrx serviceClientProxy)
        {
            if (serviceClientProxy == null)
            {
                throw ExceptionFactory.CreateCoreNullReferenceException(1000668, "Proxy is null");
            }

            try
            {
	            this.IceProxy = RemotePrxHelper.checkedCast(serviceClientProxy);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewer Remote Proxy create");
            }
            if (this.IceProxy == null)
            {
                throw ExceptionFactory.CreateCoreNullReferenceException(1000724, "IceProxy for RemoteProxy is null");
            }
        }
        /// <summary>
        /// Constructor of the Service Proxy with an callback Adapter
		/// https://doc.zeroc.com/display/Ice37/Bidirectional+Connections
        /// </summary>
        /// <param name="serviceClientProxy">the ICE client proxy for the service</param>
        /// <param name="callbackAdapter">the ICE client proxy for the service</param>
        public RemoteProxy(Ice.ObjectPrx serviceClientProxy, Ice.ObjectAdapter callbackAdapter)
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
	            this.IceProxy = RemotePrxHelper.checkedCast(serviceClientProxy);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewer Remote Proxy create");
            }
            if (this.IceProxy == null)
            {
                throw ExceptionFactory.CreateCoreNullReferenceException(1000723, "IceProxy for Remote Proxy is null");
            }

            // set the callback adapter on the client connection
            this.IceProxy.ice_getConnection().setAdapter(callbackAdapter);
        }
        /// <summary>
        /// Constructor of the Service Proxy - Create a copy with the own context.
        /// </summary>
        /// <param name="serviceClientProxy">the client proxy for the service</param>
        /// <param name="context">the per-proxy request context</param>
        public RemoteProxy(Ice.ObjectPrx serviceClientProxy, Dictionary<string, string> context)
        {
            if (serviceClientProxy == null)
            {
                throw ExceptionFactory.CreateCoreNullReferenceException(1000721, "Proxy is null");
            }

            try
            {
	            this.IceProxy = RemotePrxHelper.checkedCast(serviceClientProxy.ice_context(context));
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewer Proxy create");
            }
            if (this.IceProxy == null)
            {
                throw ExceptionFactory.CreateCoreNullReferenceException(1000652, "IceProxy for RemoteProxy is null");
            }
        }

        /// <summary>
        /// Constructor  of the Service Proxy - Create a copy with the own context.
        /// </summary>
        /// <param name="proxy">the proxy for the service</param>
        /// <param name="context">the per-proxy request context</param>
        public RemoteProxy(RemoteProxy proxy, Dictionary<string, string> context)
        {
			if (proxy == null) {
				throw ExceptionFactory.CreateCoreNullReferenceException(1000722, "Proxy is null");
			}

            try
            {
	            this.IceProxy = RemotePrxHelper.checkedCast(proxy.IceProxy.ice_context(context));
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewer Remote Proxy create");
            }
            if (this.IceProxy == null)
            {
                throw ExceptionFactory.CreateCoreNullReferenceException(1000667, "IceProxy for RemoteProxy is null");
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
					this.IceProxy = RemotePrxHelper.checkedCast(this.IceProxy.ice_context(value));
				}
				catch (Ice.Exception iceEx)
				{
					ExceptionHelper.HandleIceException(iceEx, "Remote Context");
				}
				if (this.IceProxy == null)
				{
					throw ExceptionFactory.CreateCoreNullReferenceException(1000653, "IceProxy for RemoteProxy is null");
				}
			}
        }

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
            TraceFactory.Trace(178, 0, "Calling PatternViewerRemoteService.GetVersion");

            System.Object returnValue = new System.Object();

            try
            {
                returnValue = this.IceProxy.GetVersion();
            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewerRemoteService.GetVersion");
            }

            return (AWSOA.Core.Contracts.DataTransferObject.VersionDto)returnValue;
        }
     
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public void SendInputAction(AW.Clarity.PatternViewer.Contracts.DataTransferObject.InputEventDto inputEvent)
        {
            TraceFactory.Trace(178, 0, "Calling PatternViewerRemoteService.SendInputAction\n  inputEvent '{0}'", inputEvent);

            try
            {
                this.IceProxy.SendInputAction(inputEvent);
            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewerRemoteService.SendInputAction");
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public void CreateBreakageWithReason(AW.Clarity.PatternViewer.Contracts.DataTransferObject.CreateBreakageRequestDto createBreakageRequestDto)
        {
            TraceFactory.Trace(178, 0, "Calling PatternViewerRemoteService.CreateBreakageWithReason\n  createBreakageRequestDto '{0}'", createBreakageRequestDto);

            try
            {
                this.IceProxy.CreateBreakageWithReason(createBreakageRequestDto);
            }
            catch (CommunicationException ex)
            {
                ExceptionHelper.ReThrowCoreException(ex);
            }
            catch (Ice.Exception iceEx)
            {
                ExceptionHelper.HandleIceException(iceEx, "PatternViewerRemoteService.CreateBreakageWithReason");
            }
        }
    }
}

