
# 🧠 SmartFormAutofillAnalyzer

SmartFormAutofillAnalyzer is a modern .NET Razor Pages web app that uses **Google Gemini API (LLM)** to extract and autofill structured form fields from **natural language input**.

Use it to automate:
- Contact/lead forms
- Service requests
- CRM integrations

---

## 🚀 Features

- 🌐 .NET 7+ Razor Pages Web App
- 🧠 Gemini (LLM) natural language understanding
- 📝 Autofills form fields (Name, Email, Phone, Address, Message)
- 🌍 Future-ready for multilingual support
- 🎨 Modern Bootstrap UI with responsive design

---

## 🧰 Tech Stack

- ASP.NET Core (Razor Pages)
- C#
- Google Gemini API (v1beta via REST)
- Bootstrap 5.3+
- JSON.NET / System.Text.Json

---

## 🏁 Getting Started

### 📦 Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download)
- Gemini API Key (from [Google AI Studio](https://makersuite.google.com/app))

### 🔧 Configuration

1. Add your API key in `appsettings.json`:

```json
{
  "Gemini": {
    "ApiKey": "YOUR_API_KEY_HERE"
  }
}
````

2. Optional: add to `secrets.json`:

```bash
dotnet user-secrets set "Gemini:ApiKey" "YOUR_API_KEY_HERE"
```

---

### ▶️ Run the Project

```bash
cd SmartFormAutofillAnalyzer
dotnet run
```

Visit: `https://localhost:PORT/SmartForm`

---

## 🖼️ Screenshot

![AI Email Classifier Screenshot](screenshot/AI_email\(01\).jpg)

---

## 📁 Folder Structure

```
SmartFormAutofillAnalyzer/
├── Pages/
│   └── SmartForm.cshtml + .cs
├── Services/
│   └── GeminiFormService.cs
├── Models/
│   └── FormInput.cs
├── wwwroot/
├── appsettings.json
├── Program.cs
└── README.md
```




