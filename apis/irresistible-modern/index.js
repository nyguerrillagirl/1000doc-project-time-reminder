import express from "express";
import path from "path";
import { fileURLToPath } from "url";

const PORT = process.env.PORT || 4000;
const app = express();

// Resolve __dirname in ES modules
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

// In-memory data store
const toppings = [
  { title: "pepperoni" },
  { title: "peppers" },
  { title: "pickles" }
];

// Middleware
app.use(express.static(path.join(__dirname, "public")));
app.use(express.json());

// Routes
app.get("/api/v1.0/toppings", (req, res) => {
  const enriched = toppings.map((t, i) => ({ ...t, id: i + 1 }));
  res.json({ toppings: enriched });
});

app.get("/api/v1.0/toppings/:id", (req, res) => {
  const id = Number(req.params.id);
  const index = id - 1;

  if (index < 0 || index >= toppings.length) {
    return res.status(404).send("Error 404: No topping found");
  }

  res.json({ topping: { ...toppings[index], id } });
});

app.put("/api/v1.0/toppings/:id", (req, res) => {
  const id = Number(req.params.id);
  const index = id - 1;

  if (!req.body.title) {
    return res.status(400).send("Error 400: Post syntax incorrect.");
  }

  if (index < 0 || index >= toppings.length) {
    return res.status(404).send("Error 404: No topping found");
  }

  toppings[index] = { title: req.body.title };

  res.json(true);
});

app.post("/api/v1.0/toppings", (req, res) => {
  if (!req.body.title) {
    return res.status(400).send("Error 400: Post syntax incorrect.");
  }

  toppings.push({ title: req.body.title });
  res.json(true);
});

app.delete("/api/v1.0/toppings/:id", (req, res) => {
  const id = Number(req.params.id);
  const index = id - 1;

  if (index < 0 || index >= toppings.length) {
    return res.status(404).send("Error 404: No topping found");
  }

  toppings.splice(index, 1);
  res.json(true);
});

// Views
app.set("views", path.join(__dirname, "views"));
app.set("view engine", "ejs");

app.get("/demo.html", (req, res) => res.render("pages/db"));
app.get("/", (req, res) => res.render("pages/index"));

// Start server
app.listen(PORT, () => {
  console.log(`Listening on ${PORT}`);
});