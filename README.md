<a  href="https://www.twilio.com">
<img  src="https://static0.twilio.com/marketing/bundles/marketing/img/logos/wordmark-red.svg"  alt="Twilio"  width="250"  />
</a>
 
# Twilio Sample App Template

[![Actions Status](https://github.com/twilio-labs/sample-template-nodejs/workflows/Node%20CI/badge.svg)](https://github.com/twilio-labs/sample-appointment-reminders/actions)

## About

This is a GitHub template for creating other [Twilio] sample/template apps. It contains a variety of features that should ideally be included in every Twilio sample app. You can use [GitHub's repository template](https://help.github.com/en/github/creating-cloning-and-archiving-repositories/creating-a-repository-from-a-template) functionality to create a copy of this.

Implementations in other languages:

| Java | Python | PHP | Ruby | Node |
| :--- | :----- | :-- | :--- | :--- |
| TBD | TBD | TBD | TBD | [Done](https://github.com/twilio-labs/sample-template-nodejs) |

### How it works

This application is only a barebones C# .NET Core web application built using ASP.NET Core MVC. Whenever, possible we should be using this. However, if you are using .NET Framework that comes with its own standardized application structure, you should try to merge these by using the same `README` structure and test coverage, configuration etc. as this project.

<!--
**TODO: UML Diagram**

We can render UML diagrams using [Mermaid](https://mermaidjs.github.io/).


**TODO: Describe how it works**
-->

## Features

- .NET Core web server using [ASP.NET Core MVC](https://npm.im/express)
- User interface to send SMS.
- Unit tests using [`xUnit`](https://xunit.net/) and [`Moq`](https://www.nuget.org/packages/Moq/i)
- End to End UI testing using [Selenium](https://www.selenium.dev/)
- [Automated CI testing using GitHub Actions](/.github/workflows/dotnet.yml)
- Formatting using [dotnet-format](https://www.nuget.org/packages/dotnet-format/)
- Project specific environment variables using a [JsonConfigurationProvider](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1#jcp) to load `twilio.json`.
- One click deploy buttons for Heroku, Glitch and now.sh

## How to use it

1. Create a copy using [GitHub's repository template](https://help.github.com/en/github/creating-cloning-and-archiving-repositories/creating-a-repository-from-a-template) functionality
1. Update the [`README.md`](README.md).
1. Rename the apps to your desired name and take care of the namespaces that would also require to change.
1. Build your app as necessary while making sure the tests pass.
1. Publish your app to GitHub

## Set up

### Requirements

- [dotnet](https://dotnet.microsoft.com/)
- A Twilio account - [sign up](https://www.twilio.com/try-twilio)

### Twilio Account Settings

This application should give you a ready-made starting point for writing your
own application. Before we begin, we need to collect
all the config values we need to run the application:

| Config&nbsp;Value | Description                                                                                                                                                  |
| :---------------- | :----------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Account&nbsp;Sid  | Your primary Twilio account identifier - find this [in the Console](https://www.twilio.com/console).                                                         |
| Auth&nbsp;Token   | Used to authenticate - [just like the above, you'll find this here](https://www.twilio.com/console).                                                         |
| Phone&nbsp;number | A Twilio phone number in [E.164 format](https://en.wikipedia.org/wiki/E.164) - you can [get one here](https://www.twilio.com/console/phone-numbers/incoming) |

### Local development

After the above requirements have been met:

1. Clone this repository and `cd` into it

```bash
git clone git@github.com:twilio-labs/sample-template-dotnet.git
cd sample-template-dotnet
```

2. Build to install the dependencies

```bash
dotnet build
```

3. Set your environment variables

```bash
cp twilio.json.example twilio.json
```

See [Twilio Account Settings](#twilio-account-settings) to locate the necessary environment variables.

4. Run the application

```bash
dotnet run --project TwilioSampleApp
```

5. Navigate to [http://localhost:5000](http://localhost:3000)

That's it!

### Tests

You can run the tests locally by typing:

```bash
dotnet test
```

## Resources

- [GitHub's repository template](https://help.github.com/en/github/creating-cloning-and-archiving-repositories/creating-a-repository-from-a-template) functionality

## Contributing

This template is open source and welcomes contributions. All contributions are subject to our [Code of Conduct](https://github.com/twilio-labs/.github/blob/master/CODE_OF_CONDUCT.md).

[Visit the project on GitHub](https://github.com/twilio-labs/sample-template-nodejs)

## License

[MIT](http://www.opensource.org/licenses/mit-license.html)

## Disclaimer

No warranty expressed or implied. Software is as is.

[twilio]: https://www.twilio.com
