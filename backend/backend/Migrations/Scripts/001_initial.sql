CREATE TABLE IF NOT EXISTS "Users" (
    "Id" serial PRIMARY KEY,
    "Token" text NOT NULL,
    "Query" text NOT NULL
);

CREATE TABLE IF NOT EXISTS "Messages" (
   "Id" serial PRIMARY KEY,
   "UserId" int REFERENCES "Users"("Id"),
   "Content" text NOT NULL
);

CREATE TABLE IF NOT EXISTS "MessagesBuffer" (
  "Id" serial PRIMARY KEY,
  "UserId" int REFERENCES "Users"("Id"),
  "Content" text NOT NULL
);

CREATE TABLE IF NOT EXISTS "ApprovedMessages" (
    "Id" serial PRIMARY KEY,
    "UserId" int REFERENCES "Users"("Id"),
    "Query" text NOT NULL,
    "Content" text NOT NULL
);
