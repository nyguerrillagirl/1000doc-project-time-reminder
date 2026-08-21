import { spawn } from "child_process";
import got from "got";
import test from "tape";

// Start the app on a test port
const env = { ...process.env };
env.PORT = "5000";

const child = spawn("node", ["index.js"], {
  env,
  stdio: ["pipe", "pipe", "pipe"]
});




// Helper: wait for server to print "Listening"
function waitForServerReady() {
  return new Promise(resolve => {
    child.stdout.on("data", data => {
      const text = data.toString();
      if (text.includes("Listening")) {
        resolve();
      }
    });
  });
}

test("responds to requests", async t => {
  t.plan(4);

  await waitForServerReady();
  await new Promise(r => setTimeout(r, 200));

  try {
    const response = await got("http://127.0.0.1:5000");

    // Stop the server
    child.kill();

    // Assertions
    t.ok(response, "Response object exists");
    console.log("Response body:", response.body);
    t.equal(response.statusCode, 200, "Status code is 200");
    t.notEqual(
      response.body.indexOf("<title>Irresistible APIs"),
      -1,
      "Page contains expected title"
    );
    t.notEqual(
      response.body.indexOf("Create Web APIs That Make"),
      -1,
      "Page contains expected text"
    );
  } catch (err) {
    child.kill();
    t.fail("Request failed: " + err.message);
  }
});
