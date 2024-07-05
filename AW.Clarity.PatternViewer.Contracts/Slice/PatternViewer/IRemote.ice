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
						* Remote 
						**/
					interface Remote {
						/**
						* Get the Service Version
						* @returns The service version
						**/
						idempotent AWSOA::Core::Contracts::DataTransferObject::VersionDto GetVersion() throws CommunicationException;

						/**
						* Sent an input action
						**/
						void SendInputAction(AW::Clarity::PatternViewer::Contracts::DataTransferObject::InputEventDto inputEvent) throws CommunicationException;

						/**
						* Creates a breakage with a breakage reason 
						**/
						void CreateBreakageWithReason(AW::Clarity::PatternViewer::Contracts::DataTransferObject::CreateBreakageRequestDto createBreakageRequestDto) throws CommunicationException;						
					};
				};
			};
		};
	};
};
