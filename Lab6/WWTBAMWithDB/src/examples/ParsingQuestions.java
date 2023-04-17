/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package examples;

import java.sql.*;
import java.util.*;
import java.io.File;
import java.util.logging.Level;
import java.util.logging.Logger;
/**
 *
 * @author Валерий
 */
public class ParsingQuestions {
    
    public static Connection myConn = null;
    public static String sqliteServer = "jdbc:sqlite:";
    public static String resetPath = "";

    public static boolean isDatabaseExists(String dbFilePath)
    {
        File dbFile = new File(dbFilePath);
        return dbFile.exists();
    }
    public static Connection getConnection()
    {
        sqliteServer = "jdbc:sqlite:";
        String getFilePath = new File("").getAbsolutePath();
        String fileAbsolutePath = getFilePath.concat("\\src\\examples\\database\\questions.db");
        if(isDatabaseExists(fileAbsolutePath))
        {
            try {
                myConn = DriverManager.getConnection(sqliteServer+fileAbsolutePath);
                System.out.println("Connection to SQLite has been established!");
            } catch (SQLException ex) {
                Logger.getLogger(ParsingQuestions.class.getName()).log(Level.SEVERE, null, ex);
            }

        }
        else{
            createNewDatabase("database", "questions");
            try {
                myConn = DriverManager.getConnection(sqliteServer+fileAbsolutePath);
                System.out.println("Connection to SQLite has been established!");
            } catch (SQLException ex) {
                Logger.getLogger(ParsingQuestions.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        return myConn;
    }

        public static void createNewDatabase(String fileSubFolder, String fileName){
            String getFilePath = new File("").getAbsolutePath();
            String fileAbsolutePath = "";
            
            if(fileSubFolder.isEmpty())
            {
                fileAbsolutePath = getFilePath.concat("\\src\\examples\\"+fileName+".db");
                resetPath = fileAbsolutePath;
            }
            else{
                fileAbsolutePath = getFilePath.concat("\\src\\examples\\"+fileSubFolder+"\\"+fileName+".db");
                resetPath = fileAbsolutePath;
            }
            Connection conn;
            try {
                conn = DriverManager.getConnection(sqliteServer+fileAbsolutePath);
                if(conn != null){
                    DatabaseMetaData meta = conn.getMetaData();
                    try{
                        Statement statement = conn.createStatement();
                        statement.executeQuery("CREATE TABLE table1 (ID INT PRIMARY KEY NOT NULL,"
                        + "question TEXT NOT NULL,"
                        + "answer1 TEXT NOT NULL,"
                        + "answer2 TEXT NOT NULL,"
                        + "answer3 TEXT NOT NULL,"
                        + "answer4 TEXT NOT NULL,"
                        + "answer TEXT NOT NULL,"
                        + "level INT NOT NULL);");
                        System.out.println("Create Database");
                    } catch(SQLException sqlException){
                        System.out.println("Error create Database");
                    }
                }
            } catch (SQLException ex) {
                Logger.getLogger(ParsingQuestions.class.getName()).log(Level.SEVERE, null, ex);
            }
            
        }

    
}
