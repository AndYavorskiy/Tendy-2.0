﻿using System;

namespace Tendy.DAL.Entities
{
	public class File
	{
		public int Id { get; set; }

		public int IdeaId { get; set; }
		public virtual Idea Idea { get; set; }

		public string Name { get; set; }

		public string Extension { get; set; }

		public string SourceUrl { get; set; }

		public bool? IsPrivate { get; set; }

		public DateTime? DateOfCreation { get; set; }
	}
}
