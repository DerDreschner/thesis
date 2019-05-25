/// <binding AfterBuild='03:local:sitecore:init' />
require("./scripts/gulp/local.js");
require("./scripts/unicorn/gulpfile.js");
require("./build/gulpfile.js");
require("./build/leprechaun/gulpfile.js");

