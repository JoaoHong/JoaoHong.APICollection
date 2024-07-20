using System.ComponentModel.DataAnnotations.Schema;

namespace JoaoHong.APICollection.Domain.Entities
{
	[Table("ApiCollectionUsers")]
	public class Users
	{
		[Column("UserId")]
		public long UserId { get; set; }
		[Column("Name")]
		public string Nome { get; set; }
		[Column("Password")]
		public string Senha { get; set; }
		[Column("CreatedAt")]
		[NotMapped]
		public DateTime? CreatedAt { get; set; }
		[Column("Description")]
		public string? Description { get; set; }
	}
}
