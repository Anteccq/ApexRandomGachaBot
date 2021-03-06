# ApexRandomGachaBot
[![Build](https://github.com/Anteccq/ApexRandomGachaBot/actions/workflows/build.yml/badge.svg?branch=main)](https://github.com/Anteccq/ApexRandomGachaBot/actions/workflows/build.yml)

>Apex のレジェンドと武器をランダムで決めてくれる Discord Bot です。
> 
> Season 12 まで現在対応しています。Season 13 対応予定

初回起動時にバイナリディレクトリ直下に作成される `config.json` に Discord のトークンを入力して利用してください。

Prefix の値を変更することで、コマンドの文字を切り替えることもできます。

## コマンド一覧
### レジェンド
```
!legend [number] 
[number] : プレイヤー数 規定値:1
```

### 武器
```
!weapon [number] [mode]

[number]    : 武器の本数 規定値:2
[mode]      : 
        all             全ての武器(規定値)
        +craft          フィールド武器とクラフト武器
        +carePackage    フィールド武器とケアパッケージ武器
        fieldOnly       フィールド武器のみ
```

### レジェント&武器
```
!all [number] [mode]

[number]    : プレイヤー数 規定値=1
[mode]      :
        all             全ての武器(規定値)
        +craft          フィールド武器とクラフト武器
        +carePackage    フィールド武器とケアパッケージ武器
        fieldOnly       フィールド武器のみ
```

### フルパ用エイリアス
```
!legendp
'legend 3' と同じ
```

```
!weaponp [mode]
'weapon 6 [mode]' と同じ
```

```
!allp [mode]
'all 3 [mode]' と同じ
```

### ヘルプ
```
!apex-h
!help (alias)
```

## 開発環境
### Requirement
* [.NET 6](https://dotnet.microsoft.com/ja-jp/download/dotnet/6.0)

### Build & Run
1. ApexRandomGachaBot.csproj ファイルがあるディレクトリまで移動
1. `dotnet build -c Release` 
1. bin/Release/net6.0 ディレクトリに移動
1. `dotnet ./ApexRandomGachaBot.dll` (初回起動時は構成ファイル作成後に終了)
1. config.json ファイルの Token の値に Discord のトークンを記入
1. `dotnet ./ApexRandomGachaBot.dll` を再度実行。

## License
Under the MIT.

## Special Thanks
- [AI-Avalon](https://github.com/AI-Avalon)