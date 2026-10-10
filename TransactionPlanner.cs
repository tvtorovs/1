
var ledger = new Ledger();
decimal sum = 0;
ledger.Add(new(DateOnly.FromDateTime(DateTime.Today), Category.Food, 19.50m, "Breakfast"));
ledger.Add(new(DateOnly.FromDateTime(DateTime.Today), Category.Food, 10.20m, "Lunch"));
ledger.Add(new(DateOnly.FromDateTime(DateTime.Today), Category.Rent, 485.00m, "Rent For October"));
ledger.Add(new(DateOnly.FromDateTime(DateTime.Today), Category.Bills, 110.10m, "Bills for October"));
ledger.Add(new(DateOnly.FromDateTime(DateTime.Today), Category.Transport, 5.50m, "Daysaver"));
ledger.Add(new(DateOnly.FromDateTime(DateTime.Today), Category.Other, 50.50m, "Cosplay Order"));
ledger.Add(new(DateOnly.FromDateTime(DateTime.Today), Category.Other, 14.99m, "Steam Purchase"));


foreach (var (cat, total) in ledger.CategorySums()) {
    Console.WriteLine($"{cat}: {total:C}");
    sum = sum + total;
}

Console.WriteLine($"Total: {sum:C}");

public enum Category {Food, Rent, Transport, Bills, Other }

public record Transaction(DateOnly date, Category category, decimal amount, string note);

public class Ledger {
    private readonly List<Transaction> items = new(); 

    public void Add(Transaction t) => items.Add(t); 

    public Dictionary<Category, decimal> CategorySums() => 
        items.GroupBy(t => t.category).ToDictionary(g => g.Key, g => g.Sum(t => t.amount));
}

