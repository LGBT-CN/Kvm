# Kvm

## Introduction

Kvm is a simple tool for generating HTML quickly. It generates HTML by splitting `.Kvm` files into different chunks and merging Props.

## Syntax

### `.Kvm`

General, `Kvm` is blocks like following:

```kvm
{% Property Content %}
```

If you want to type `{%` into HTML, you should write like:

```kvm
{{%
```

### Property


```
# Comment should starts with '#'
# Key value pair should be done like A = B
Key=Value
```

## Usage

```pwsh
.\Kvm.ConsoleApp.exe $ConfigName
```

Example, our config name is `conf.json`, run like:

```pwsh
.\Kvm.ConsoleApp.exe conf.json
```

However, to make things simple, the `ConfigName` is set as `config.json` by default. If your config name is `config.json` accidentally, you don't need type `ConfigName` again. Just run like:

```pwsh
.\Kvm.ConsoleApp.exe
```

## Platforms Supported

All platforms which are supported by .NET 5.

## LICENSE

Kvm is licensed under [OKZPL](LICENSE).
