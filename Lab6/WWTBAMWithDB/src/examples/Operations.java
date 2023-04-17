/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package examples;
import java.sql.*;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
/**
 *
 * @author Валерий
 */
public class Operations {
    public static void insertData( int ID, String question, String answer1, 
            String answer2, String answer3, String answer4, String answer, int level){
        String sqlQuery = "INSERT INTO table1 (ID,question,answer1,answer2,"
                + "answer3,answer4,answer,level) VALUES(?,?,?,?,?,?,?,?);";
        
        try {
            Connection conn = ParsingQuestions.getConnection();
            PreparedStatement preparedStatement;
            preparedStatement = conn.prepareStatement(sqlQuery);
            preparedStatement.setInt(1,ID);
            preparedStatement.setString(2,question);
            preparedStatement.setString(3,answer1);
            preparedStatement.setString(4,answer2);
            preparedStatement.setString(5,answer3);
            preparedStatement.setString(6,answer4);
            preparedStatement.setString(7,answer);
            preparedStatement.setInt(8,level);
            preparedStatement.executeUpdate();
            System.out.println("Data has been inserted!");
        } catch (SQLException ex) {
            Logger.getLogger(Operations.class.getName()).log(Level.SEVERE, null, ex);
        }
        
    }
    public static boolean fillDatabase(ArrayList<Question> questions)
    {
        int id = 0;
        for(Question question:questions)
        {
            insertData(id, question.Text, question.Answers[0], 
                    question.Answers[1], question.Answers[2], question.Answers[3], 
                    question.RightAnswer, question.Level);
            id++;
        }
        return true;
    }
}
