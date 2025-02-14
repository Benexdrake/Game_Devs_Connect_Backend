
-- User
CREATE TABLE IF NOT EXISTS user
(
    id text PRIMARY KEY,
    username text,
    avatar text,
    accountType text,
    banner text,
    discordUrl text,
    xurl text,
    websiteurl text,
    email text    
);

-- Project
CREATE TABLE IF NOT EXISTS project
(
    id text PRIMARY KEY,
    headerimage text,
    name text,
    description text,
    ownerid text
);

CREATE TABLE IF NOT EXISTS project_team
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    projectid text,
    teammemberid text
);

-- Tag
CREATE TABLE IF NOT EXISTS tag
(
    name text PRIMARY KEY
);

-- Request
CREATE TABLE IF NOT EXISTS request
(
    id text PRIMARY KEY,
    title text,
    description text,
    fileurl text,
    created text,
    projectId text,
    userId text
);

CREATE TABLE IF NOT EXISTS request_tag
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    requestId text,
    tagname text
);

-- Element
CREATE TABLE IF NOT EXISTS element
(
    id text PRIMARY KEY,
    elementtype INTEGER,
    content text,
    config text,
    nr INTEGER,
    projectid text
);