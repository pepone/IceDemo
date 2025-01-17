 
//----------------------
// <auto-generated>
//     AWSOA.Core.CodeGeneration
// </auto-generated>
//----------------------
#pragma once
/** Includes for Domain types **/
#include <Ice/BuiltinSequences.ice>
#include <PatternViewer/CoreDto.generated.ice>
#include <PatternViewer/PVSheetTypeDto.generated.ice>

module AW{
    module Clarity{        
		module PatternViewer{
			module Contracts {
				module DataTransferObject{
					// Create the class for the DTO					
					["format:sliced","clr:property"]
					class AdditionalSheetInformationDto  
					{
						AWSOA::Core::Contracts::DataTransferObject::GuidDto \InputGuid;
						int \ShapeNumber;
						string \LabelNumber;
						bool \IsGroupLabel;							
						string \CustomerName;
						int \StandingEdge;
						string \Notes;
						string \Coating;
						optional(1) AW::Clarity::PatternViewer::Contracts::DataTransferObject::PVSheetTypeDto \SheetType;
					};
				};
			};
		};
	};
};
