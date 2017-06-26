﻿using System;
using System.Collections.Generic;
using iayos.flashcardapi.DomainModel.Flags;
using ServiceStack.DataAnnotations;

namespace iayos.flashcardapi.Domain.Concrete.MsSql.Tables
{
	[Alias("Deck")]
	public class DeckTable : AuditableTable
	{
		[PrimaryKey]
		public Guid DeckId { get; set; }


		[References(typeof(ApplicationTable))]
		public Guid ApplicationId { get; set; }

		[Reference]
		public ApplicationTable Application { get; set; }


		public string Name { get; set; }

		/// <summary>
		/// What language are the faces of the cards recorded in?
		/// </summary>
		public LanguageFlag FrontLanguage { get; set; } = LanguageFlag.ENGLISH;


		/// <summary>
		/// What language are the backs of the cards recorded in?
		/// </summary>
		public LanguageFlag BackLanguage { get; set; } = LanguageFlag.ENGLISH;


		[Reference]
		public ICollection<CardTable> Cards { get; set; } = new List<CardTable>();

	}
}