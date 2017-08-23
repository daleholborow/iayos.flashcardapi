using System;
using System.Collections.Generic;

namespace iayos.flashcardapi.Domain.Dto.Application
{

	public class ApplicationDto
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public List<DeckCategoryDto> DeckCategoryDtos { get; set; } = new List<DeckCategoryDto>();

	}
}