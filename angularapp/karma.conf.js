module.exports = function (config) {
  // Prefer Puppeteer's Chromium for headless runs when available,
  // but only set CHROME_BIN if the executable actually exists.
  try {
    // eslint-disable-next-line @typescript-eslint/no-var-requires
    const puppeteer = require('puppeteer');
    const fs = require('fs');
    const pPath = typeof puppeteer.executablePath === 'function'
      ? puppeteer.executablePath()
      : puppeteer.executablePath;
    if (pPath && fs.existsSync(pPath) && !process.env.CHROME_BIN) {
      process.env.CHROME_BIN = pPath;
    }
  } catch (e) {
    // puppeteer not installed or path invalid; fall back to system Chrome
  }

  config.set({
    basePath: "",
    frameworks: ["jasmine", "@angular-devkit/build-angular"],
    plugins: (function() {
      const plugins = [
        require("karma-jasmine"),
        require("karma-chrome-launcher"),
        require("karma-jasmine-html-reporter"),
        require("karma-coverage")
      ];
      try {
        plugins.push(require("@angular-devkit/build-angular/plugins/karma"));
      } catch (e) {
        plugins.push(require("@angular/build/plugins/karma"));
      }
      return plugins;
    })(),
    client: {
      jasmine: {
        // you can add configuration options for Jasmine here
        // the possible options are listed at https://jasmine.github.io/api/edge/Configuration.html
        // for example, you can disable the random execution with `random: false`
        // or set a specific seed with `seed: 4321`
      },
      clearContext: false // leave Jasmine Spec Runner output visible in browser
    },
    jasmineHtmlReporter: {
      suppressAll: true // removes the duplicated traces
    },
    coverageReporter: {
      dir: require("path").join(__dirname, "./coverage/"),
      subdir: ".",
      reporters: [
        { type: "html" },
        { type: "text-summary" }
      ]
    },
    reporters: ["progress", "kjhtml"],
    customLaunchers: {
      ChromeHeadlessNoSandbox: {
        base: 'ChromeHeadless',
        flags: ['--no-sandbox', '--disable-setuid-sandbox']
      }
    },
    browsers: [process.env.CI ? 'ChromeHeadlessNoSandbox' : 'ChromeHeadlessNoSandbox'],
    port: 9876,
    colors: true,
    logLevel: config.LOG_INFO,
    autoWatch: true,
    singleRun: false,
    restartOnFileChange: true,
    listenAddress: "localhost",
    hostname: "localhost"
  });
};

