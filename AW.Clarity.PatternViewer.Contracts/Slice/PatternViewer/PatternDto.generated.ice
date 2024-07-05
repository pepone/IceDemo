﻿ 
//----------------------
// <auto-generated>
//     AWSOA.Core.CodeGeneration
// </auto-generated>
//----------------------
#pragma once
/** Includes for Domain types **/
#include <Ice/BuiltinSequences.ice>
#include <PatternViewer/CoreDto.generated.ice>
#include <PatternViewer/CuttingLevelEnumsDto.generated.ice>
#include <PatternViewer/CoordinateOriginEnumsDto.generated.ice>
#include <PatternViewer/PatternDescriptionDto.generated.ice>

module AW{
    module Clarity{        
        module PatternViewer{
            module Contracts {
                module DataTransferObject{
                    // Create the class for the DTO
                    ["clr:property"]
                    class PatternDto  
                    {
                        AWSOA::Core::Contracts::DataTransferObject::GuidDto \Guid;
                        AW::Clarity::PatternViewer::Contracts::DataTransferObject::RectangleDto \Rectangle;
                        AW::Clarity::PatternViewer::Contracts::DataTransferObject::PatternRectangleDto \RootRectangle;
                        DefectDtoSeq \Defects;
                        string \HeaderText;
                        AW::Clarity::PatternViewer::Contracts::DataTransferObject::CoordinateOriginDto \Origin;
                        AW::Clarity::PatternViewer::Contracts::DataTransferObject::CuttingLevelDto \ZoomLevel;
                        LogoDtoSeq \Logos;                        
                        optional(2) AW::Clarity::PatternViewer::Contracts::DataTransferObject::PatternDescriptionDto \Description;                     
                        optional(3) TextColumnDtoSeq \HeaderInformation;
                    };
                };
            };
        };
    };
};
