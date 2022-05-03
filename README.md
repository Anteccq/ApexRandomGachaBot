# ApexRandomGachaBot
>Apex のレジェンドと武器をランダムで決めてくれる Discord Bot です。
> 
> Season 12 まで現在対応しています。Season 13 対応予定

初回起動時に作成される `config.json` に Discord のトークンを入力して利用してください。

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
* .NET 6

## License
Under the MIT.

## Special Thanks
- [AI-Avalon](https://github.com/AI-Avalon)