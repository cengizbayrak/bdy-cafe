package com.bdy.cafe.handler;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;
import android.os.Handler;
import android.support.v7.app.AlertDialog;
import android.util.Log;

import com.bdy.cafe.R;
import com.bdy.cafe.model.User;
import com.bdy.cafe.runnable.AddAdditionTable;
import com.bdy.cafe.runnable.InitialConnectionRunnable;
import com.bdy.cafe.utility.MyUtil;

import java.lang.ref.WeakReference;

/**
 * Created by cngz on 26.12.2016.
 * <p>
 * <b>SQL operations</b>
 * <ul>
 * <b color="blue">Operations:</b>
 * <li>{@link InitialConnectionRunnable}</li>
 * <li>{@link AddAdditionTable}</li>
 * </ul>
 */
public class SQLHandler extends AsyncTask<Void, Void, Boolean> {
    private static final String TAG = "SQLHandler";

    private WeakReference<Context> weakReference;

//    private Context context;

    private int additionNumber = -1;
    private int tableNumber = -1;

    private ProgressDialog progressDialog;

    private SQLHandler() {

    }

    public SQLHandler(Context context, int additionNumber, int tableNumber) {
        this.weakReference = new WeakReference<>(context);

//        this.context = context;

        this.additionNumber = additionNumber;
        this.tableNumber = tableNumber;
    }

    @Override
    protected void onPreExecute() {
        super.onPreExecute();

        User.executingTransaction = true;

//        progressDialog = MyUtil.Global.getProgressDialog(context, R.string.addition_table_info, R.string.info_transferring_to_main_pc, false);
        progressDialog = MyUtil.Global.getProgressDialog(weakReference.get(), R.string.addition_table_info, R.string.info_transferring, false);
        progressDialog.show();
    }

    @Override
    protected Boolean doInBackground(Void... params) {
        // params wrong
        if (additionNumber == -1 || tableNumber == -1) {
            Log.d(TAG, "doInBackground: additionNumber=" + additionNumber + ", tableNumber=" + tableNumber);
            return false;
        }

        // get max
        InitialConnectionRunnable initialConnectionRunnable = new InitialConnectionRunnable();
        initialConnectionRunnable.run();

        // add
        AddAdditionTable addAdditionTable = new AddAdditionTable(additionNumber, tableNumber);
        addAdditionTable.run();
        return addAdditionTable.getResult();
    }

    @Override
    protected void onPostExecute(Boolean aBoolean) {
        if (progressDialog != null) {
            progressDialog.dismiss();
        }

//        String title = context.getString(R.string.addition_table_info);
        String title = weakReference.get().getString(R.string.addition_table_info);
//        String message = context.getString(R.string.addition_table_info_sent_successfully_order_brought_to_you_bon_appetit);
        String message = weakReference.get().getString(R.string.addition_table_info_sent_successfully_order_brought_to_you_bon_appetit);
        MyUtil.Global.Type type = MyUtil.Global.Type.info;
        message = String.format(message, additionNumber, tableNumber);
        if (!aBoolean) {
//            message = context.getString(R.string.addition_number_sent_already_please_check_info_try_again);
            message = weakReference.get().getString(R.string.addition_number_sent_already_please_check_info_try_again);
            message = String.format(message, additionNumber);
            type = MyUtil.Global.Type.error;
        }

//        final AlertDialog dialog = MyUtil.Global.getAlertDialog(context, title, message, type);
        final AlertDialog dialog = MyUtil.Global.getAlertDialog(weakReference.get(), title, message, type);
        dialog.setCancelable(true);

        // show for messageDuration miliseconds
        final int duration = 8000;
        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                dialog.dismiss();
            }
        }, duration);

        User.executingTransaction = false;
    }
}