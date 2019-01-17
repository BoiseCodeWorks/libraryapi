-- CREATE TABLE Library(
--   id int NOT NULL AUTO_INCREMENT, 
--   name VARCHAR(255), 
--   city VARCHAR(255),
--   PRIMARY KEY(id)
-- );

-- CREATE TABLE Book(
--   id int NOT NULL AUTO_INCREMENT, 
--   title VARCHAR(255), 
--   description VARCHAR(255),
--   authorId int NOT NULL,
--   FOREIGN KEY (authorId) REFERENCES Author(id),
--   PRIMARY KEY(id)
-- );

-- ALTER TABLE Book 
-- ADD isbn string



-- CREATE TABLE LibraryBooks (
--   id int NOT NULL AUTO_INCREMENT,
--   bookId int NOT NULL,
--   libraryId int NOT NULL,

--   PRIMARY KEY (id),
--   INDEX ( libraryId, bookId),

--   FOREIGN KEY (libraryId)
--     REFERENCES Library(id)
--       ON DELETE CASCADE,

--   FOREIGN KEY (bookId)
--     REFERENCES Book(id)
--       ON DELETE CASCADE
-- );

