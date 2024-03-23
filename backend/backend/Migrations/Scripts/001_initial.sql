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
    "Keyword" text NOT NULL,
    "Title" text NOT NULL,
    "SessionString" text NOT NULL,
    "ChatId" int NOT NULL,
    "MessageId" int NOT NULL,
    "IsFound" boolean NOT NULL,
    "Content" text NOT NULL
);
