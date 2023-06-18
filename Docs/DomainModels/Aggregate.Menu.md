## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
    "id": "00000000-0000-00000-0000-000000000",
    "name": "Yummy Menu",
    "description": "A menu with Yummy food",
    "averageRating": 4.5
    "sections": [
        {
            "id": "00000000-0000-00000-0000-000000000",
            "name": "Appetizers",
            "description": "Starters",
            "items": [
                {
                     "id": "00000000-0000-00000-0000-000000000",
                    "name": "Fried Pickles",
                    "description": "Depp fried pickles",
                    "price": 5.99
                }
            ]
        }
    ],
    "createDateTime": "2020-01-01T00:00:00.0000000Z",
    "updateDateTime": "2020-01-01T00:00:00.0000000Z",
    "hostId": "00000000-0000-00000-0000-000000000",
    "dinnerIds": [
         "value": "00000000-0000-00000-0000-000000000",
    ],
    "menuReviewIds": [
         "value": "00000000-0000-00000-0000-000000000",
    ]
}
```
