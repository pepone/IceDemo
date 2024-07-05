#pragma once
/** Includes for Domain types **/
#include <Ice/BuiltinSequences.ice>
#include <PatternViewer/CoreDto.generated.ice>
/** include all Dtos and Enums **/
#include <PatternViewer/IncludeDtos.generated.ice>
module AW{
    module Clarity{
		module PatternViewer{
			module Contracts {						
				module Interfaces {
					/**
					* PatternViewerCallback 
					**/
					interface PatternViewerCallback {
						/**
						* Callback routine from PatternViewer to report an input event.
						* @param inputEvent The input event which was triggered (like left mouse button).
						**/
						void InputEvent(AW::Clarity::PatternViewer::Contracts::DataTransferObject::InputEventDto inputEvent, optional(3) string machineLabel);

						/**
						* Callback routine from PatternViewer which breakage reason is selected.
						* @param sheet The guid of the sheet for which the breakage was selected.
						* @param reason The breakage reason number which was selected.
						**/
						idempotent void BreakageReasonSelected(AWSOA::Core::Contracts::DataTransferObject::GuidDto sheet, int reason, optional(4) string machineLabel);

						/**
						* Callback routine from PatternViewer if next or previos button is pressed.
						* @param stepPatternEvent The stepPatternEvent event which was triggert.
						**/
						void StepPattern(AW::Clarity::PatternViewer::Contracts::DataTransferObject::StepPatternEventDto stepPatternEvent, optional(5) string machineLabel);

						/**
						* Callback routine from PatternViewer for crating a breakage with a breakage reason.
						* @param sheet The guid of the sheet for which the breakage was selected.
						* @param reason The breakage reason number which was selected.
						**/
						idempotent void CreateBreakageWithReason(AW::Clarity::PatternViewer::Contracts::DataTransferObject::CreateBreakageRequestDto createBreakageRequestDto, string machineLabel);
					};
				};
			};
		};
	};
};
