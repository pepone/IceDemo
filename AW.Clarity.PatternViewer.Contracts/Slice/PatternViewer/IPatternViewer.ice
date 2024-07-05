#pragma once
/** Includes for Domain types **/
#include <Ice/BuiltinSequences.ice>
#include <Ice/Identity.ice>
#include <PatternViewer/CoreDto.generated.ice>
/** include all Dtos and Enums **/
#include <PatternViewer/IncludeDtos.generated.ice>
module AW{
    module Clarity{        
		module PatternViewer{
			module Contracts {						
				module Interfaces {
					/**
					* PatternViewer 
					**/
					interface PatternView extends ServiceBase {

						/**
						* Shows a Pattern and header, footer and message informations in the pattern viewer.
						* @param pattern The pattern which should be shown in the pattern viewer.
						* @param headerInformation The header information (text and type) which should be shown in the pattern viewer.
						* @param footerInformation The footer information (text and type) which should be shown in the pattern viewer.
						* @param informations The information messages which should be shown in the pattern viewer.
						* @param singleShett Enable the Next and Previous Pattern Buttons in singleSheet = false.
						**/
						["format:sliced"]
						idempotent void ShowPattern(AW::Clarity::PatternViewer::Contracts::DataTransferObject::PatternDto pattern, AW::Clarity::PatternViewer::Contracts::DataTransferObject::HeaderInformationDto headerInformation, AW::Clarity::PatternViewer::Contracts::DataTransferObject::FooterInformationDto footerInformation, AW::Clarity::PatternViewer::Contracts::DataTransferObject::StringDtoSeq informations, optional(1) bool singleSheet, optional(2) bool showInfoText) throws CommunicationException;

						/**
						* Shows the breakage reason dialog in the pattern viewer.
						**/
						idempotent void ShowBreakageReasons() throws CommunicationException;

						/**
						* Hiddes the breakage reason dialog in the pattern viewer.
						**/
						idempotent void RemoveBreakageReasons() throws CommunicationException;

						/**
						* Shutdowns the pattern viewer instance.
						**/
						idempotent void Shutdown() throws CommunicationException;

						/**
						* Subscribe to the pattern viewer to receive callback information.
						* @param machineLabel The machine label for the current pattern viewer instance.
						* @param identity An unique identity to "identify" the callback listener.
						**/
						idempotent bool LogOn(string machineLabel, Ice::Identity identity) throws CommunicationException;
						/**
						* Unsubscribe from the pattern viewer to stop receiving callback information.
						* @param machineLabel The machine label for the current pattern viewer instance.
						* @param identity An unique identity to "identify" which callback listener should be unsubscribe
						**/
						idempotent bool LogOff(string machineLabel, Ice::Identity identity) throws CommunicationException;							
						/**
						* Retrieves the Guid of the current shown pattern
						**/
						idempotent AWSOA::Core::Contracts::DataTransferObject::GuidDto CurrentPattern() throws CommunicationException;	
					};
				};
			};
		};
	};
};
