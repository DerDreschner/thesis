/// <binding AfterBuild='03:local:sitecore:init' ProjectOpened='03:local:sitecore:init, 04:leprechaun:generate:watch' />
require("./build/gulpfile.js");
require("./build/leprechaun/gulpfile.js");