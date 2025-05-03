using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmAnthropicClaudeWeb;

public partial class HmAnthropicClaudeWeb
{
    private const byte VK_ESC = 0x1B; // ESCキーの仮想キーコード

    private const byte VK_SLASH = 0xBF; // スラッシュキーの仮想キーコード

    
    private const byte VK_BACKSPACE = 0x08;// BACKSPACEキーの仮想キーコード



    public void SendShiftEscSlashDelSync()
    {
        var task = SendShiftSendEscSlashDel();
        task.Wait();
    }

    private async Task SendShiftSendEscSlashDel()
    {
        // Ctrl キーを解放
        keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
        // Alt キーを解放
        keybd_event(VK_ALT, 0, KEYEVENTF_KEYUP, 0);

        // Shift キーを押す
        keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYDOWN, 0);

        // ESC キーを押下
        keybd_event(VK_ESC, 0, KEYEVENTF_KEYDOWN, 0);

        await Task.Delay(100);

        // ESC キーを解放
        keybd_event(VK_ESC, 0, KEYEVENTF_KEYUP, 0);

        // Shift キーを解放
        keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);


        // スラッシュキーを押下
        keybd_event(VK_SLASH, 0, KEYEVENTF_KEYDOWN, 0);
        await Task.Delay(100);

        // スラッシュキーを解放
        keybd_event(VK_SLASH, 0, KEYEVENTF_KEYUP, 0);

        await Task.Delay(200);

        // DELキーを押下
        keybd_event(VK_BACKSPACE, 0, KEYEVENTF_KEYDOWN, 0);
        await Task.Delay(100);

        // DELキーを解放
        keybd_event(VK_BACKSPACE, 0, KEYEVENTF_KEYUP, 0);
    }


}
