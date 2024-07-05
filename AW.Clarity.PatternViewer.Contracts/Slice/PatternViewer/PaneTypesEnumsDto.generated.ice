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
			module Contracts {
				module DataTransferObject{

					// Create the enum for the DTO
					["cs:attribute:System.Flags"]
					enum PaneTypesDto 
					{
						NonePaneTypesDto = 0,
						StandardPaneTypesDto = 1,
						BreakagePaneTypesDto = 2,
						ShapePaneTypesDto = 4,
						QuickPaneTypesDto = 8,
						ManualEnteredPaneTypesDto = 16,
						RestrictionViolationPaneTypesDto = 32,
						//Spacer2PaneTypesDto = 64,
						//Spacer3PaneTypesDto = 128,
						//Spacer4PaneTypesDto = 256,
						//Spacer5PaneTypesDto = 512,
						//Spacer6PaneTypesDto = 1024,
						//Spacer7PaneTypesDto = 2048,
						//Spacer8PaneTypesDto = 4096,						
						Custom11PaneTypesDto = 8192,
						Custom12PaneTypesDto = 16384,
						Custom1PaneTypesDto = 32768,
						Custom2PaneTypesDto = 65536,
						Custom3PaneTypesDto = 131072,
						Custom4PaneTypesDto = 262144,
						Custom5PaneTypesDto = 524288,
						Custom6PaneTypesDto = 1048576,
						Custom7PaneTypesDto = 2097152,
						Custom8PaneTypesDto = 4194304,
						Custom9PaneTypesDto = 8388608,
						Custom10PaneTypesDto = 16777216
					};


					// define collection of enum
					["clr:generic:List"]
					sequence<PaneTypesDto> PaneTypesDtoSeq;

				};
			};
		};
	};
};