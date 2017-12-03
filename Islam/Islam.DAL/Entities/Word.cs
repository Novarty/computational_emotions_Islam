using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Islam.DAL.Entities
{
	public class Word 
	{
		public Word()
		{
			Vectors = new HashSet<Vector>();
		}

		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Value { get; set; }	

		public ICollection<Vector> Vectors { get; set; }
	}
}
