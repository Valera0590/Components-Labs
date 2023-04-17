/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/GUIForms/JFrame.java to edit this template
 */
package examples;


import java.awt.Color;
import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.stream.Collectors;
import javax.swing.*;

/**
 *
 * @author Валерий
 */
public class GameFrame extends JFrame {

    ArrayList<Question> questions;
    private Random  rnd;
    int Level;
    Question currentQuestion;

    
    /**
     * Creates new form GameFrame
     */
    public GameFrame() {
        
        super("WhoWantsToBeAMillionaire");
        super.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        initComponents();
        this.Level = 0;
        this.rnd = new Random();
        this.questions = new ArrayList<Question>();
        lablePic.setText("");
        lablePic.setIcon(new ImageIcon("picture.jpg"));
        ReadFile();
        startGame();
        
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        btnFiftyFifty = new javax.swing.JButton();
        btnPeopleHelp = new javax.swing.JButton();
        btnCallFriend = new javax.swing.JButton();
        jButton4 = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        lstLevel = new javax.swing.JList<>();
        lblQuestionText = new javax.swing.JLabel();
        btnAnswer1 = new javax.swing.JButton();
        btnAnswer3 = new javax.swing.JButton();
        btnAnswer2 = new javax.swing.JButton();
        btnAnswer4 = new javax.swing.JButton();
        lablePic = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        btnFiftyFifty.setText("50/50");
        btnFiftyFifty.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnFiftyFiftyActionPerformed(evt);
            }
        });

        btnPeopleHelp.setText("Помощь зала");
        btnPeopleHelp.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnPeopleHelpActionPerformed(evt);
            }
        });

        btnCallFriend.setText("Звонок другу");
        btnCallFriend.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnPeopleHelpActionPerformed(evt);
            }
        });

        jButton4.setText("Забрать деньги");
        jButton4.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton4ActionPerformed(evt);
            }
        });

        lstLevel.setModel(new javax.swing.AbstractListModel<String>() {
            String[] strings = { "3 000 000", "1 500 000", "   800 000", "   400 000", "   200 000", "   100 000", "     50 000", "     25 000", "     15 000", "     10 000", "       5 000", "       3 000", "       2 000", "       1 000", "          500" };
            public int getSize() { return strings.length; }
            public String getElementAt(int i) { return strings[i]; }
        });
        jScrollPane1.setViewportView(lstLevel);

        lblQuestionText.setFont(new java.awt.Font("Segoe UI", 0, 14)); // NOI18N
        lblQuestionText.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lblQuestionText.setText("lblQuestionText");
        lblQuestionText.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);

        btnAnswer1.setActionCommand("1");
        btnAnswer1.setLabel("btnAnswer1");
        btnAnswer1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnAnswer1ActionPerformed(evt);
            }
        });

        btnAnswer3.setText("btnAnswer3");
        btnAnswer3.setActionCommand("3");
        btnAnswer3.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnAnswer1ActionPerformed(evt);
            }
        });

        btnAnswer2.setText("btnAnswer2");
        btnAnswer2.setActionCommand("2");
        btnAnswer2.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnAnswer1ActionPerformed(evt);
            }
        });

        btnAnswer4.setText("btnAnswer4");
        btnAnswer4.setActionCommand("4");
        btnAnswer4.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnAnswer1ActionPerformed(evt);
            }
        });

        lablePic.setText("jLabel1");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(16, 16, 16)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(jButton4, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(btnCallFriend, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(btnPeopleHelp, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(btnFiftyFifty, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                        .addGap(18, 18, 18)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(lblQuestionText, javax.swing.GroupLayout.PREFERRED_SIZE, 447, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(lablePic, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                        .addGap(29, 29, 29)
                        .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 93, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(btnAnswer1, javax.swing.GroupLayout.DEFAULT_SIZE, 342, Short.MAX_VALUE)
                            .addComponent(btnAnswer2, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(btnAnswer3, javax.swing.GroupLayout.DEFAULT_SIZE, 349, Short.MAX_VALUE)
                            .addComponent(btnAnswer4, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))))
                .addContainerGap(52, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(32, 32, 32)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(44, 44, 44)
                        .addComponent(btnFiftyFifty)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(btnPeopleHelp)
                        .addGap(14, 14, 14)
                        .addComponent(btnCallFriend)
                        .addGap(36, 36, 36)
                        .addComponent(jButton4))
                    .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 285, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(lablePic, javax.swing.GroupLayout.PREFERRED_SIZE, 271, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(lblQuestionText, javax.swing.GroupLayout.PREFERRED_SIZE, 78, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btnAnswer1)
                    .addComponent(btnAnswer3))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btnAnswer2)
                    .addComponent(btnAnswer4, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addContainerGap(29, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    
    private void btnFiftyFiftyActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnFiftyFiftyActionPerformed
        // TODO add your handling code here:
        JButton[] btns = new JButton[]{btnAnswer1, btnAnswer2, 
            btnAnswer3, btnAnswer4};
        
        int count = 0;
        while (count<2)
        {
            int n = rnd.nextInt(4);
            String ac = btns[n].getActionCommand();
            
            if (!ac.equals(currentQuestion.RightAnswer)
                    && btns[n].isEnabled())
            {
                btns[n].setEnabled(false);
                count++;
            }
        }
        btnFiftyFifty.setEnabled(false);
    }//GEN-LAST:event_btnFiftyFiftyActionPerformed

    private void btnAnswer1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnAnswer1ActionPerformed
        // TODO add your handling code here:
        if (currentQuestion.RightAnswer.equals(evt.getActionCommand()))
            NextStep();            
        else
        {
            JOptionPane.showMessageDialog(this, "Неверный ответ!");
            startGame();
        }
    }//GEN-LAST:event_btnAnswer1ActionPerformed

    private void btnPeopleHelpActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnPeopleHelpActionPerformed
        // TODO add your handling code here:
        JButton[] btns = new JButton[]{btnAnswer1, btnAnswer2, 
            btnAnswer3, btnAnswer4};
        boolean flag = true;
        while(flag)
        {
            int n = rnd.nextInt(4);
            if(btns[n].isEnabled())
            {
                btns[n].setBackground(Color.getHSBColor(51, 24, 93));
                flag = false;
            }
        }
        
        String ac = evt.getActionCommand();
        ((JButton) evt.getSource()).setEnabled(false);
    }//GEN-LAST:event_btnPeopleHelpActionPerformed

    private void jButton4ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton4ActionPerformed
        // TODO add your handling code here:
        startGame();
    }//GEN-LAST:event_jButton4ActionPerformed

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(GameFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(GameFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(GameFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(GameFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new GameFrame().setVisible(true);
            }
        });
    }

    private void ReadFile()
    {
        try{
            FileInputStream fstream = new FileInputStream("Вопросы.txt");
            BufferedReader br = new BufferedReader(new InputStreamReader(fstream));
            String strLine;

            while ((strLine = br.readLine()) != null) {
                String[] s = strLine.split("\t");
                questions.add(new Question(s));
            }
            Operations.fillDatabase(questions);
        } catch (IOException e) {
            System.out.println("Ошибка");
        }
    }
    
    private void ShowQuestion(Question q)
    {
        final String html = "<html><body style='width: %1spx'>%1s";
        lblQuestionText.setText(String.format(html, 400, q.Text));
        btnAnswer1.setText(q.Answers[0]);
        btnAnswer2.setText(q.Answers[1]);
        btnAnswer3.setText(q.Answers[2]);
        btnAnswer4.setText(q.Answers[3]);
        JButton[] btns = new JButton[]{btnAnswer1, btnAnswer2, 
            btnAnswer3, btnAnswer4};
        for(JButton bt : btns)
            bt.setBackground(Color.LIGHT_GRAY);
    }

    private Question GetQuestion(int level)
    {
        List<Question> list = questions.stream().filter(q->q.Level==level).collect(Collectors.toList());
        return list.get(rnd.nextInt(list.size()));
    }

    private void NextStep()
    {
        JButton[] btns = new JButton[]{btnAnswer1, btnAnswer2, 
            btnAnswer3, btnAnswer4};
        
        for(JButton btn: btns)
            btn.setEnabled(true);
        
        Level++;
        currentQuestion = GetQuestion(Level);
        ShowQuestion(currentQuestion);
        lstLevel.setSelectedIndex(lstLevel.getModel().getSize()-Level);
    }

    private void startGame()
    {
        Level = 0;
        NextStep();
        btnFiftyFifty.setEnabled(true);
        btnCallFriend.setEnabled(true);
        btnPeopleHelp.setEnabled(true);
    }




    
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnAnswer1;
    private javax.swing.JButton btnAnswer2;
    private javax.swing.JButton btnAnswer3;
    private javax.swing.JButton btnAnswer4;
    private javax.swing.JButton btnCallFriend;
    private javax.swing.JButton btnFiftyFifty;
    private javax.swing.JButton btnPeopleHelp;
    private javax.swing.JButton jButton4;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JLabel lablePic;
    private javax.swing.JLabel lblQuestionText;
    private javax.swing.JList<String> lstLevel;
    // End of variables declaration//GEN-END:variables
}