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
					enum CuttingLevelDto 
					{
						PlateCuttingLevelDto = 0,
						Level1CuttingLevelDto = 1,
						Level2CuttingLevelDto = 2,
						Level3CuttingLevelDto = 3,
						Level4CuttingLevelDto = 4,
						Level5CuttingLevelDto = 5,
						Level6CuttingLevelDto = 6,
						Level7CuttingLevelDto = 7,
						Level8CuttingLevelDto = 8,
						Level9CuttingLevelDto = 9,
						Level10CuttingLevelDto = 10,
						PrimitiveCuttingLevelDto = 98,
						SheetCuttingLevelDto = 99,
					};


					// define collection of enum
					["clr:generic:List"]
					sequence<CuttingLevelDto> CuttingLevelDtoSeq;
				};
			};
		};
	};
};
