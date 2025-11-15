# Como Usar o Sistema de Traduções

## Visão Geral

O sistema de traduções automático permite que todos os formulários da aplicação carreguem traduções do banco de dados local SQLite automaticamente quando são abertos.

## Como Aplicar Traduções em um Formulário

Para aplicar traduções em qualquer formulário, basta adicionar **UMA LINHA** no evento `Load` do formulário:

```vb
Private Sub NomeDoFormulario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    ' ... seu código existente ...
    
    ' Aplica traduções automaticamente
    Module_fun.ApplyTranslations(Me)
    
    ' ... resto do código ...
End Sub
```

### Exemplo Completo

```vb
Public Class Frm_MeuFormulario
    Private Sub Frm_MeuFormulario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configurações iniciais do formulário
        Icon = New Icon(".\Pictures\icon.ico")
        
        ' Configura logo
        Logo.Image = My.Resources.ResourcesPic.mainLogo
        
        ' APLICA AS TRADUÇÕES - UMA LINHA APENAS!
        Module_fun.ApplyTranslations(Me)
        
        ' Resto da lógica do formulário
        LoadData()
    End Sub
End Class
```

## O Que é Traduzido Automaticamente

A função `ApplyTranslations()` traduz automaticamente os seguintes componentes:

### Controles Suportados:
- ? **Form** (título do formulário)
- ? **Label**
- ? **Button**
- ? **CheckBox**
- ? **RadioButton**
- ? **GroupBox**
- ? **TabControl**
- ? **TabPage**
- ? **TextBox**
- ? **ComboBox**
- ? **LinkLabel**
- ? **Panel**
- ? **ColumnHeader** (ListView)

### Componentes de Menu/ToolStrip:
- ? **MenuStrip**
- ? **ToolStrip**
- ? **StatusStrip**
- ? **ToolStripButton**
- ? **ToolStripDropDownButton**
- ? **ToolStripMenuItem**
- ? **ToolStripLabel**
- ? **ToolStripDropDownItem**

## Como Funciona

1. **Carregamento do Idioma**: A função busca o idioma atual configurado no banco de dados local (`tbl_User` ? `Local_LanguageId`)

2. **Busca de Traduções**: Carrega todas as traduções do formulário da tabela `cfg_Translation` no SQLite

3. **Aplicação Automática**:
   - Percorre todos os controles do formulário (incluindo aninhados)
   - Busca a tradução correspondente para cada componente
   - Se encontrar tradução, aplica; se não, mantém o texto original

4. **Fallback Seguro**: Se não houver tradução para um componente específico, o sistema mantém o valor `Text` original definido no designer

## Pré-requisitos

### 1. Banco de Dados Local Atualizado

Certifique-se de que o banco de dados local está atualizado com as traduções:

```vb
' Isso normalmente é feito no formulário principal de Landing
Call Frm_00_02_Translations.LoadLocalTranslationDb()
```

### 2. Idioma Configurado

O idioma do usuário deve estar configurado na tabela `tbl_User`:

```sql
-- Exemplo: Configurar idioma Espanhol (ID = 2)
UPDATE tbl_User 
SET FieldText = '2' 
WHERE FieldName = 'Local_LanguageId';
```

### 3. Traduções Cadastradas

As traduções devem estar cadastradas no banco de dados remoto e sincronizadas localmente usando o formulário `Frm_00_02_Translations`.

## Estrutura do Banco de Dados Local

### Tabela: `cfg_Translation`

```sql
CREATE TABLE cfg_Translation (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    FormName TEXT NOT NULL,           -- Ex: "Frm_00_01_Landing"
    ObjectName TEXT NOT NULL,         -- Ex: "Btn_01_VMS"
    LanguageID INTEGER NOT NULL,      -- Ex: 2 (Espanhol)
    TranslationText TEXT,             -- Ex: "Sistema VMS"
    UNIQUE(FormName, ObjectName, LanguageID)
);
```

## Vantagens do Sistema

? **Simplicidade**: Uma única linha de código por formulário  
? **Automático**: Traduz todos os componentes suportados automaticamente  
? **Seguro**: Não quebra se não houver traduções  
? **Recursivo**: Traduz controles aninhados (dentro de GroupBox, Panel, etc.)  
? **Completo**: Inclui menus, toolstrips e dropdowns  
? **Fallback**: Mantém texto original se não houver tradução  

## Solução de Problemas

### Traduções Não Aparecem

1. **Verifique o idioma configurado**:
```vb
Dim languageId = Module_db.QueryTable_SQLite("SELECT FieldText FROM tbl_User WHERE FieldName = 'Local_LanguageId';")
' Deve retornar um ID válido (diferente de 0)
```

2. **Verifique se as traduções existem no banco local**:
```vb
Dim translations = Module_db.QueryTable_SQLite("SELECT * FROM cfg_Translation WHERE FormName = 'NomeDoFormulario';")
' Deve retornar registros
```

3. **Atualize o banco de dados local**:
   - Abra `Frm_00_02_Translations`
   - Clique em "Update Local DB"

### Nome do Componente Não Corresponde

Certifique-se de que o nome do componente no designer corresponde ao nome registrado no banco de dados:

- **Designer**: `Btn_01_Save` (propriedade Name)
- **Banco**: `ObjectName = 'Btn_01_Save'`

Os nomes devem ser **exatamente iguais**, incluindo maiúsculas/minúsculas.

## Melhores Práticas

1. **Sempre nomeie seus controles**: Dê nomes significativos aos controles (não use `Button1`, `Label1`)

2. **Aplique traduções no final do Load**: Coloque `ApplyTranslations()` depois de todas as configurações iniciais

3. **Teste com múltiplos idiomas**: Configure diferentes idiomas e teste a tradução

4. **Mantenha textos originais em inglês**: Use inglês nos designers para ter uma base consistente

5. **Sincronize regularmente**: Atualize o banco local quando houver novas traduções

## Exemplo de Workflow Completo

```vb
Public Class Frm_01_00_LandingVMS
    Private Sub Frm_01_00_LandingVMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Configurações visuais
        Icon = New Icon(".\Pictures\icon.ico")
        Logo.Image = My.Resources.ResourcesPic.VivantLogo
        Me.WindowState = FormWindowState.Maximized
        
        ' 2. Carrega dados
        LoadInitialData()
        
        ' 3. APLICA TRADUÇÕES (sempre no final)
        Module_fun.ApplyTranslations(Me)
    End Sub
    
    Private Sub LoadInitialData()
        ' Sua lógica de carregamento de dados
    End Sub
End Class
```

## Próximos Passos

Para adicionar suporte a novos tipos de controles, edite o array `TranslatableTypes` em `Module_fun.vb`.
