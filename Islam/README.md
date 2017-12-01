# Api

Сервис имеет POST запрос с одним параметром и возвращет 
занчение для каждой эмоции.

url: {host}/analyzer/analyze

Формат запроса:
```
{
    "text" : "some text"
}
```

Формат ответа:
```
{
    "items": [
        {
            "emotion": "anger",
            "value": 0
        },
        {
            "emotion": "anticipation",
            "value": 0
        },
        {
            "emotion": "disgust",
            "value": 0
        },
        {
            "emotion": "fear",
            "value": 0
        },
        {
            "emotion": "joy",
            "value": 0
        },
        {
            "emotion": "sudness",
            "value": 0
        },
        {
            "emotion": "surprise",
            "value": 0
        },
        {
            "emotion": "trust",
            "value": 0
        }
    ]
}
```
