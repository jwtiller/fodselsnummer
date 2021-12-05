# Norske fødselsnummer

[![NuGet version (Norske.Fodselsnummer)](https://img.shields.io/nuget/v/Norske.Fodselsnummer.svg?style=flat-square)](https://www.nuget.org/packages/Norske.Fodselsnummer/)

## Validering
```csharp
var fnr = new Fodselsnummer("12345678911");
var valid = fnr.IsValid();
```

## Generering
### Dato
```csharp
var fnr = Fodselsnummer.Generate(new DateOnly(2021,01,01)); // year,month,day
```
### Kjønn
```csharp
var fnr = Fodselsnummer.Generate(new DateOnly(2021,01,01),Gender.Male);
var fnr = Fodselsnummer.Generate(new DateOnly(2021,01,01),Gender.Female);
```
