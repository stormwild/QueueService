using ChannelSample;

//var simpleRunner = new SimpleChannelRunner();
//await simpleRunner.RunAsync();

//var channelRunner = new ChannelRunner();
//await channelRunner.RunAsync();

var boundedChannelRunner = new BoundedChannelRunner(1000, 2000);
await boundedChannelRunner.RunAsync();

Console.ReadKey();
