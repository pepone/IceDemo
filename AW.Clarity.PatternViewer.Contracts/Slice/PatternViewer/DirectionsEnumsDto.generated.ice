﻿ 
//----------------------
// <auto-generated>
//     AWSOA.Core.CodeGeneration
// </auto-generated>
//----------------------
#pragma once

module AW{
    module Clarity{
		module PatternViewer{
			module Contracts{
				module DataTransferObject{				 
					// Create the enum for the DTO
					["cs:attribute:System.Flags"]
					enum DirectionDto 
					{
						UndefinedDirectionDto = 0,
						CounterclockwiseDirectionDto = 1,
						ClockwiseDirectionDto = 2						
					};


					// define collection of enum
					["clr:generic:List"]
					sequence<DirectionDto> DirectionDtoSeq;
				};
			};
		};
	};
};