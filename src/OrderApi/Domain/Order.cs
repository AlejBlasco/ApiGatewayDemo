namespace OrderApi.Domain;

public record Order(int Id, int ProductId, int Quantity);
